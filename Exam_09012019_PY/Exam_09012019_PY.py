# Todor Milev Gerganov, 246684

# Q 6
# Q 6a

# Q 6b

# Q 6c
traitPoints = [('Caring', 9), ('Kind', 6), ('Social', 5), ('Innovative', 7), ('Programming', 8)]
max(traitPoints, key = lambda sprice: sprice[1]) # ('Caring', 9)

# Q 7a
itrCities = ["Copenhagen", "Aarhus", "Aalborg", "Horsens", "Odense"]
usingFilter = list(filter(lambda y: , itrCities)) # I could not figure out the filtering function itself
print(usingFilter) # Should result in the (newly created) filtered list

# Q b
class Student:
    def __init__(self, studentName, studentNumber, department):
        self.studentName = studentName
        self.studentNumber = studentNumber
        self.department = department

    def display(self):
        print('Displaying student')

class Worker:
    def getSalary(self, hoursWorked):
        print(hoursWorked*120)

class StudentWorker(Student, Worker):
    pass

# Testing
sw = StudentWorker("Todor", "111", "IT", 5)