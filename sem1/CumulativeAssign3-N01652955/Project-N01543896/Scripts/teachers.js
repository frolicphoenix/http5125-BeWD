function AddTeacher() {
	//This method is for sendng an AJAX request to add a teacher to the database
	//POST : http://localhost:56968/api/TeacherData/AddTeacher
	

	var URL = "http://localhost:56968/api/TeacherData/AddTeacher/";

	var rq = new XMLHttpRequest();
	

	var TeacherFname = document.getElementById('TeacherFname').value;
	var TeacherLname = document.getElementById('TeacherLname').value;
	var EmployeeNumber = document.getElementById('EmployeeNumber').value;
	var Salary = document.getElementById('Salary').value;



	var TeacherData = {
		"TeacherFname": TeacherFname,
		"TeacherLname": TeacherLname,
		"EmployeeNumber": EmployeeNumber,
		"Salary": Salary,
	};


	rq.open("POST", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	rq.onreadystatechange = function () {
		
		if (rq.readyState == 4 && rq.status == 200) {
			console.log(TeacherData)
		}

	}
	rq.send(JSON.stringify(TeacherData));

}

function UpdateTeacher(TeacherId) {

	//POST : http://localhost:56968/api/TeacherData/UpdateTeacher/{id}
	//with POST data of teacherFName, teacherLName, emplyeeNumber, Salary, etc.

	var URL = "http://localhost:56968/api/TeacherData/UpdateTeacher/" + TeacherId;

	var rq = new XMLHttpRequest();

	var TeacherFName = document.getElementById('TeacherFname').value;
	var TeacherLName = document.getElementById('TeacherLname').value;
	var EmployeeNumber = document.getElementById('EmployeeNumber').value;
	var HireDate = document.getElementById('HireDate').value;
	var Salary = document.getElementById('Salary').value;



	var TeacherData = {
		"TeacherFname": TeacherFName,
		"TeacherLname": TeacherLName,
		"EmployeeNumber": EmployeeNumber,
		"HireDate": HireDate,
		"Salary": Salary
	};


	rq.open("POST", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	rq.onreadystatechange = function () {
		
		if (rq.readyState == 4 && rq.status == 200) {
		}

	}
	rq.send(JSON.stringify(TeacherData));

}