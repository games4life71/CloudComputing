from http.server import BaseHTTPRequestHandler, HTTPServer
import json

from Controllers.CarController import CarController
from Database.Database import Database


class CustomHandler(BaseHTTPRequestHandler):
    def __init__(self, db, *args, **kwargs, ):
        self.car_controller = CarController(db)
        super().__init__(*args, **kwargs)

    def do_GET(self):
        if self.path == '/cars':
            # get all the cars
            cars = self.car_controller.get_all_cars()
            if cars:
                self.send_response(200)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps([car.to_dict() for car in cars]).encode())
                return
            else:
                self.send_response(405)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps({'message': 'Bad request'}).encode())
                return



        elif self.path.startswith('/cars/'):
            #get the id from the query string
            car_id = self.path.split('/')[-1]
            car = self.car_controller.get_car(car_id)
            if car:
                self.send_response(200)
                self.send_header('Content-type', 'application/json')
                self.end_headers()
                self.wfile.write(json.dumps(car.to_dict()).encode())
                return
            else:
                self.send_response(405)
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

    def do_POST(self):
        if self.path == '/':
            self.send_response(200)
            self.send_header('Content-type', 'application/json')
            self.end_headers()
            self.wfile.write(json.dumps({'message': 'Hello, World!'}).encode())
            return
        else:
            self.send_response(404)
            self.send_header('Content-type', 'application/json')
            self.end_headers()
            self.wfile.write(json.dumps({'message': 'Not Found'}).encode())
            return

    def do_PUT(self):
        if self.path == '/':
            self.send_response(200)
            self.send_header('Content-type', 'application/json')
            self.end_headers()
            self.wfile.write(json.dumps({'message': 'Hello, World!'}).encode())
            return
        else:
            self.send_response(404)
            self.send_header('Content-type', 'application/json')
            self.end_headers()
            self.wfile.write(json.dumps({'message': 'Not Found'}).encode())
            return

    def do_DELETE(self):
        if self.path == '/':
            self.send_response(200)
            self.send_header('Content-type', 'application/json')
            self.end_headers()
            self.wfile.write(json.dumps({'message': 'Hello, World!'}).encode())
            return
        else:
            self.send_response(404)
            self.send_header('Content-type', 'application/json')
            self.end_headers()
            self.wfile.write(json.dumps({'message': 'Not Found'}).encode())
            return
