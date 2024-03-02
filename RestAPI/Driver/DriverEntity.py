import uuid

class Driver:
    def __init__(self,name,team):
        self.name = name
        self.team = team
        self.id = uuid.uuid4().__str__()
