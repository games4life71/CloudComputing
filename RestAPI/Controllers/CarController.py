import Repositories.CarsRepos.CarRepository as CarRepository


class CarController:
    def __init__(self, db):
        self.repository = CarRepository.CarRepo(db)

    def get_all_cars(self):
        cars = self.repository.get_cars()

        # return self.repository.get_cars()
        return cars

    def get_car(self, car_id):
        car = self.repository.get_car(car_id)
        if car:
            return car
        else:
            return "Car not found"


    def add_car(self, car):
        return self.repository.add_car(car)


