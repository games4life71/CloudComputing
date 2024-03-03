import uuid


class Driver:
    def __init__(self, name, team):
        self.name = name
        self.team = team
        self.id = uuid.uuid4().__str__()

    @classmethod
    def from_dict(cls, driver_dict):
        driver = cls(driver_dict["name"], driver_dict["team"])
        return driver

    @classmethod
    def with_id(cls, id, name, team):
        driver = cls(name, team)
        driver.id = id
        return driver

    def to_dict(self):
        return {
            "id": self.id,
            "name": self.name,
            "team": self.team
        }