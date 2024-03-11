import sqlite3

from Car.CarEntity import Car
from Driver.DriverEntity import Driver


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
            return car.id, True
        except sqlite3.Error as e:
            return e, False

    def get_cars(self):
        try:
            rows = self.cursor.execute("SELECT * FROM Car")
            if rows:
                return [Car.with_id(row[0], row[1], row[2], row[3]) for row in rows], True

        except sqlite3.Error as e:
            success = False
            return e, success

    def get_car(self, car_id):
        try:
            self.cursor.execute("SELECT * FROM Car WHERE id = ?", (car_id,))
            rows = self.cursor.fetchone()
            if rows:
                return Car.with_id(rows[0], rows[1], rows[2], rows[3]), True
            else:
                return "No car found", False

        except sqlite3.Error as e:
            success = False
            return e, success

    def update_car(self, car_id, car):
        try:
            self.cursor.execute("UPDATE Car SET name = ?, speed = ?, year = ? WHERE id = ?",
                                (car.name, car.speed, car.year, car_id))
            self.conn.commit()
            if self.cursor.rowcount == 0:
                return "Bad request", False
            return car.id, True
        except sqlite3.Error as e:
            success = False
            return e, success

    def delete_car(self, car_id):
        try:
            result = self.cursor.execute("DELETE FROM Car WHERE id = ?", (car_id,))
            self.conn.commit()
            if self.cursor.rowcount == 0:
                return "No car found", False
            return car_id, True
        except sqlite3.Error as e:
            success = False
            return e, success

    def get_all_drivers(self):
        try:
            rows = self.cursor.execute("SELECT * FROM Drivers")
            if rows:
                return [Driver.with_id(row[0], row[1], row[2]) for row in rows], True

        except sqlite3.Error as e:
            success = False
            return e, success

    def get_driver_by_id(self, driver_id):
        try:
            self.cursor.execute("SELECT * FROM Drivers WHERE id = ?", (driver_id,))
            rows = self.cursor.fetchone()
            if rows:
                return Driver.with_id(rows[0], rows[1], rows[2]), True
            else:
                return "No driver found", False

        except sqlite3.Error as e:
            success = False
            return e, success
        pass

    def create_driver(self, driver):

        try:
            self.cursor.execute("INSERT INTO Drivers (id, name, team_name) VALUES (?, ?, ?)",
                                (driver.id, driver.name, driver.team))
            self.conn.commit()
            return driver.id, True
        except sqlite3.Error as e:
            success = False
            return e, success

    def update_driver(self, driver_id, driver):
        try:
            self.cursor.execute("UPDATE Drivers SET name = ?, team_name = ? WHERE id = ?",
                                (driver.name, driver.team, driver_id))
            self.conn.commit()
            if self.cursor.rowcount == 0:
                return "Bad request", False
            return driver.id, True
        except sqlite3.Error as e:
            success = False
            return e, success
        pass

    def delete_driver(self, driver_id):
        try:
            self.cursor.execute("DELETE FROM Drivers WHERE id = ?", (driver_id,))
            self.conn.commit()
            if self.cursor.rowcount == 0:
                return "No driver found", False  # No rows were deleted
            else:
                return driver_id, True
        except sqlite3.Error as e:
            success = False
            return e, success
