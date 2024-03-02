import sqlite3

from Car.CarEntity import Car


class Database:
    def __init__(self, db_name):
        self.db_name = db_name
        self.conn = sqlite3.connect(self.db_name)
        self.cursor = self.conn.cursor()

    def add_car(self, car):
        try:
            self.cursor.execute("INSERT INTO Car (id, name, speed, year) VALUES (?, ?, ?, ?)",
                                (car.id, car.name, car.speed, car.year))
            self.conn.commit()
            return car.id
        except sqlite3.Error as e:
            return e

    def get_cars(self):
        try:
            rows = self.cursor.execute("SELECT * FROM Car")
            if rows:
                return [Car.with_id(row[0], row[1], row[2], row[3]) for row in rows]

        except sqlite3.Error as e:
            return e

    def get_car(self, car_id):
        try:
            self.cursor.execute("SELECT * FROM Car WHERE id = ?", (car_id,))
            rows = self.cursor.fetchone()
            if rows:
                return Car.with_id(rows[0], rows[1], rows[2], rows[3])
            else:
                return None

        except sqlite3.Error as e:
            return e

    def update_car(self, car_id, car):
        try:
            self.cursor.execute("UPDATE Car SET name = ?, speed = ?, year = ? WHERE id = ?",
                                (car.name, car.speed, car.year, car_id))
            self.conn.commit()
            return car.id
        except sqlite3.Error as e:
            return e

    def delete_car(self, car_id):
        try:
            self.cursor.execute("DELETE FROM Car WHERE id = ?", car_id)
            self.conn.commit()
            return car_id
        except sqlite3.Error as e:
            return e
