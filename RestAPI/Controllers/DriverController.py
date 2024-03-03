import Repositories.DriversRepos.DriverRepository as DriverRepository


class DriverController:

    def __init__(self, db):
        self.repository = DriverRepository.DriverRepository(db)

    def get_all_drivers(self):
        drivers = self.repository.get_all_drivers()
        return drivers

    def get_driver_by_id(self, driver_id):
        driver = self.repository.get_driver_by_id(driver_id)
        if driver:
            return driver
        else:
            return "Driver not found"

    def update_driver(self, driver_id, driver):
        return self.repository.update_driver(driver_id, driver)

    def delete_driver(self, driver_id):
        return self.repository.delete_driver(driver_id)

    def add_driver(self, driver_data):
        print("driver_data", driver_data)
        return self.repository.create_driver(driver_data)
