import uuid


class Car:
    def __init__(self, name, speed, year):
        self.name = name
        self.speed = speed
        self.year = year
        self.id = uuid.uuid4().__str__()

    @classmethod
    def with_id(cls, id, name, speed, year):
        car = cls(name, speed, year)
        car.id = id
        return car

    def to_dict(self):
        return {
            "id": self.id,
            "name": self.name,
            "speed": self.speed,
            "year": self.year
        }

    def ChangeName(self, newName):
        self.name = newName

    def ChangeYear(self, newYear):
        self.year = newYear

    def ChangeSpeed(self, newSpeed):
        if newSpeed < 0:
            raise ValueError("Speed cannot be negative")

        self.speed = newSpeed

    #create a car object from a dictionary
    @classmethod
    def from_dict(cls, car_dict):
        car = cls(car_dict["name"], car_dict["speed"], car_dict["year"])
        return car
        pass
