import random
class Test():
    def __init__(self, name):
        self.name = name
    def display(self):
        return "Hi, " + self.name
    def random_number(self, start, end):
    	return random.randint(start, end)