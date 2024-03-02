import uuid

class Race:
    def __init__(self,car_id,position):
        self.car_id = car_id
        self.position = position
        self.id = uuid.uuid4().__str__()

