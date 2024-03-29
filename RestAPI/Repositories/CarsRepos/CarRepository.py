from Car.CarEntity import Car
from Database.Database import Database


class CarRepo:
    def __init__(self, db: Database):
        self.db = db

    def get_cars(self):
        return self.db.get_cars()

    def get_car(self, car_id: int):
        return self.db.get_car(car_id)

    def add_car(self, car: Car):
        #map the car object to a dictionary
        car_to_add = Car.from_dict(car)
        return self.db.add_car(car_to_add)

    def update_car(self, car_id, car:Car):
        car_to_update = Car.from_dict(car)
        return self.db.update_car(car_id, car_to_update)

    def delete_car(self, car_id: int):
        return self.db.delete_car(car_id)
