# # create a new car and add it to the database
# from Car.CarEntity import Car
from Car.CarEntity import Car
from Database.Database import Database
# import Repositories.CarsRepos.CarRepository as CarRepository
#
# new_car = Car(1, "Toyota", 200)
#
db = Database("D:\Projects\CloudComputing\RestAPI\my_api.db")
#
# car_repo = CarRepository.CarRepo(db)
#
# car_repo.add_car(new_car)
from http.server import HTTPServer
#
from Controllers.CustomHandler import CustomHandler
#
PORT = 8000
httpd = HTTPServer(('localhost', PORT), lambda *args, **kwargs: CustomHandler(db, *args, **kwargs))
print(f"Server running on port {PORT}")
httpd.serve_forever()

