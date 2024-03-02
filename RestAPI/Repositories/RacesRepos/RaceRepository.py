class RaceRepository:
    def __init__(self, db):
        self.db = db

    def get_races(self):
        return self.db.get_races()

    def get_race(self, race_id):
        return self.db.get_race_by_id(id)

    def add_race(self, race):
        return self.db.add_race(race)
