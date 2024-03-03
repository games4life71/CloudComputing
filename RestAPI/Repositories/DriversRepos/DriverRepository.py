from Database.Database import Database
from Driver.DriverEntity import Driver


class DriverRepository:
    def __init__(self, db:Database):
        self.db = db

    def get_all_drivers(self):
        return self.db.get_all_drivers()

    def get_driver_by_id(self, driver_id):
        return self.db.get_driver_by_id(driver_id)

    def create_driver(self, driver):
        driver_to_add = Driver.from_dict(driver)
        print("driver_to_add", driver_to_add.name)
        return self.db.create_driver(driver_to_add)

    def update_driver(self, driver_id, driver):
        driver_to_update = Driver.from_dict(driver)

        return self.db.update_driver(driver_id, driver_to_update)

    def delete_driver(self, driver_id):
        return self.db.delete_driver(driver_id)
