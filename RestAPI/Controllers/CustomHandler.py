from base64 import encode
from http.server import BaseHTTPRequestHandler, HTTPServer
import json

from Car.CarEntity import Car
from Controllers.CarController import CarController
from Controllers.DriverController import DriverController
from Database.Database import Database


class CustomHandler(BaseHTTPRequestHandler):
    def __init__(self, db, *args, **kwargs, ):
        self.car_controller = CarController(db)
        self.driver_controller = DriverController(db)
        super().__init__(*args, **kwargs)

    def do_GET(self):
        if self.path == '/cars':
            # get all the cars
            cars = self.car_controller.get_all_cars()
            if not cars[1]:
                self.send_response(400)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps({'message': cars[0]}).encode())
                return
            else:
                self.send_response(200)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps([car.to_dict() for car in cars[0]]).encode())
                return

                self.send_response(405)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps({'message': 'Bad request'}).encode())
                return

        elif self.path == '/drivers':
            try:
                # get all the drivers
                drivers = self.driver_controller.get_all_drivers()
                if drivers[1]:
                    self.send_response(200)
                    self.send_header('Content-type', 'application/json')
                    self.end_headers()
                    self.wfile.write(json.dumps([driver.to_dict() for driver in drivers[0]]).encode())
                    return
                else:
                    self.send_response(400)
                    self.send_header('Content-type', 'application/json')
                    self.end_headers()
                    self.wfile.write(json.dumps({'message': drivers[0]}).encode())
                    return
            except Exception as e:
                self.send_response(400)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps({'message': str(e)}).encode())
                return

        elif self.path.startswith('/cars/'):
            try:
                # get the id from the query string
                car_id = self.path.split('/')[-1]
                car = self.car_controller.get_car(car_id)
                if car[1]:
                    self.send_response(200)
                    self.send_header('Content-type', 'application/json')
                    self.end_headers()
                    self.wfile.write(json.dumps(car[0].to_dict()).encode())
                    return
                else:
                    self.send_response(405)
                    self.send_header('Content-type', 'application/json')
                    self.end_headers()
                    self.wfile.write(json.dumps({'message': car[0]}).encode())
                    return
            except Exception as e:
                self.send_response(400)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                print(e)
                self.wfile.write(json.dumps({'message': 'An error occured'}).encode())
                return

        elif self.path.startswith('/drivers/'):
            try:
                driver_id = self.path.split('/')[-1]
                driver = self.driver_controller.get_driver_by_id(driver_id)
                if driver[1]:
                    self.send_response(200)
                    self.send_header('Content-type', 'application/json')
                    self.end_headers()
                    self.wfile.write(json.dumps(driver[0].to_dict()).encode())
                    return
                else:
                    self.send_response(405)
                    self.send_header('Content-type', 'application/json')
                    self.end_headers()
                    self.wfile.write(json.dumps({'message': driver[0]}).encode())
                    return
            except Exception as e:
                self.send_response(400)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps({'message': str(e)}).encode())
                return

        else:
            self.send_response(404)
            self.send_header('Content-type', 'application/json')
            self.end_headers()
            self.wfile.write(json.dumps({'message': 'Not Found'}).encode())
            return

    def do_POST(self):
        if self.path == '/cars/add-car':
            try:
                # Read the request body and parse it into a dictionary
                data = self.rfile.read(int(self.headers['Content-Length']))
                car_data = json.loads(data)
                car_id = self.car_controller.add_car(car_data)
                if not car_id[1]:
                    self.send_response(400)
                    self.send_header('Content-type', 'application/json')
                    self.end_headers()
                    self.wfile.write(json.dumps({'message': car_id[0]}).encode())
                    return

                # Send a response with the ID of the new car
                self.send_response(201)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps({'id': car_id[0]}).encode())
            except Exception as e:
                # If there's an error, send a 400 response with an error message
                self.send_response(400)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps({'message': 'Failed to create new Car'}).encode())

        elif self.path == '/drivers/add-driver':
            try:
                # Read the request body and parse it into a dictionary
                data = self.rfile.read(int(self.headers['Content-Length']))
                driver_data = json.loads(data)
                driver_id = self.driver_controller.add_driver(driver_data)
                # Send a response with the ID of the new driver
                self.send_response(200)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps({'id': driver_id[0], 'succes': driver_id[1]}).encode())
                return
            except Exception as e:
                # If there's an error, send a 400 response with an error message
                self.send_response(400)
                print(e)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps({'message': 'Bad request'}).encode())
                return
        else:
            self.send_response(404)
            self.send_header('Content-type', 'application/json')
            self.end_headers()
            self.wfile.write(json.dumps({'message': 'Not Found'}).encode())
            return

    def do_PUT(self):
        if self.path.startswith('/cars/update-car/'):
            try:
                # Extract the car ID from the path
                car_id = self.path.split('/')[-1]

                # Read the request body and parse it into a dictionary
                data = self.rfile.read(int(self.headers['Content-Length']))
                car_data = json.loads(data)

                # Update the car in the database
                result = self.car_controller.update_car(car_id, car_data)
                if not result[1]:
                    self.send_response(400)
                    self.send_header('Content-type', 'application/json')
                    self.end_headers()
                    self.wfile.write(json.dumps({'message': result[0]}).encode())
                    return
                # Send a success response
                self.send_response(200)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps({'message': 'Car updated successfully ', 'data': result[0]}).encode())
                return
            except Exception as e:
                # If there's an error, send a 400 response with an error message
                self.send_response(400)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps({'message': str(e)}).encode())

        if self.path.startswith('/drivers/update-driver/'):
            try:
                # Extract the driver ID from the path
                driver_id = self.path.split('/')[-1]

                # Read the request body and parse it into a dictionary
                data = self.rfile.read(int(self.headers['Content-Length']))
                driver_data = json.loads(data)

                # Update the driver in the database
                result=self.driver_controller.update_driver(driver_id, driver_data)
                if result[1]:
                    # Send a success response
                    self.send_response(200)
                    self.send_header('Content-type', 'application/json')
                    self.end_headers()
                    self.wfile.write(json.dumps({'data': result[0],'succes':result[1]}).encode())
                    return
                else:
                    self.send_response(400)
                    self.send_header('Content-type', 'application/json')
                    self.end_headers()
                    self.wfile.write(json.dumps({'message': result[0],'succes':result[1]}).encode())
                    return
            except Exception as e:
                # If there's an error, send a 400 response with an error message
                self.send_response(400)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps({'message': "Bad request"}).encode())
        else:
            self.send_response(404)
            self.send_header('Content-type', 'application/json')
            self.end_headers()
            self.wfile.write(json.dumps({'message': 'Not Found'}).encode())

    def do_DELETE(self):
        if self.path.startswith('/cars/delete-car/'):
            try:
                car_id = self.path.split('/')[-1]
                car = self.car_controller.delete_car(car_id)
                if car[1]:
                    self.send_response(200)
                    self.send_header('Content-type', 'application/json')
                    self.end_headers()
                    self.wfile.write(json.dumps({'message': 'Car deleted'}).encode())
                    return
                else:
                    self.send_response(405)
                    self.send_header('Content-type', 'application/json')
                    self.end_headers()
                    self.wfile.write(json.dumps({'message': 'Bad request'}).encode())
                    return
            except Exception as e:
                self.send_response(400)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps({'message': str(e)}).encode())
                return

        elif self.path.startswith('/drivers/delete-driver/'):
            try:
                driver_id = self.path.split('/')[-1]
                driver = self.driver_controller.delete_driver(driver_id)
                if driver[1]:
                    self.send_response(200)
                    self.send_header('Content-type', 'application/json')
                    self.end_headers()
                    self.wfile.write(json.dumps({'message': 'Driver deleted'}).encode())
                    return
                else:
                    self.send_response(405)
                    self.send_header('Content-type', 'application/json')
                    self.end_headers()
                    self.wfile.write(json.dumps({'message': 'Bad request'}).encode())
                    return
            except Exception as e:
                self.send_response(400)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps({'message': str(e)}).encode())
                return
        else:
            self.send_response(404)
            self.send_header('Content-type', 'application/json')
            self.end_headers()
            self.wfile.write(json.dumps({'message': 'Not Found'}).encode())
            return
