class DriverRepository:
    def __init__(self, db):
        self.db = db

    def get_all_drivers(self):
        return self.db.get_all_drivers()

    def get_driver_by_id(self, driver_id):
        return self.db.get_driver_by_id(driver_id)

    def create_driver(self, driver):
        return self.db.create_driver(driver)

    def update_driver(self, driver_id, driver):
        return self.db.update_driver(driver_id, driver)

    def delete_driver(self, driver_id):
        return self.db.delete_driver(driver_id)
