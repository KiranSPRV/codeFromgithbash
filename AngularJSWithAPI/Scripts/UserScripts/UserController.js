var app = angular.module("myApp", ['ngRoute']);
app.config(function ($routeProvider) {
	$routeProvider
		.when("/", {
			templateUrl: "User/index.cshtml"
		})
		.when("/red", {
			templateUrl: "School/index.cshtml"
		})
		.when("/green", {
			templateUrl: "green.htm"
		})
		.when("/blue", {
			templateUrl: "blue.htm"
		});
});


//create a factory "MathService" which provides a method multiply to return multiplication of two numbers
app.factory('MathService', function () {

	var factory = {};
	var AgeType;
	factory.multiply = function (x) {
		if (x < 18) {
			AgeType = 'Minor';
		}
		else if (x > 20 && x < 60) {
			AgeType = 'Adult';
		}
		else if (x > 60) {
			AgeType = 'Senior Citizen';
		}
		return AgeType;
	}
	return factory;
});

//inject the factory "MathService" in a service to utilize the multiply method of factory.
app.service('CalcService', function (MathService) {
	this.square = function (a) {
		console.log(MathService.multiply(a));
		return MathService.multiply(a);
	}
});

app.controller("myCtrl", function ($scope, $http, CalcService) {
	$scope.User = {};
	GetAllUsers();
	$scope.InsertUser = function (isValid) {
		if ($scope.UserID == undefined) {
			$scope.UserID = 0;
		}
		$scope.User.UserID = $scope.UserID;
		$scope.User.UserName = $scope.UserName;
		$scope.User.City = $scope.City;
		$scope.User.Age = $scope.Age;
		debugger;
		var ageType = CalcService.square($scope.Age);
		alert(ageType);
		$http({
			method: "post",
			url: "User/Insert_User",
			datatype: "json",
			data: JSON.stringify($scope.User)
		}).then(function successCallback(response) {
			alert(response.data);
			$scope.UserID = "";
			$scope.UserName = "";
			$scope.City = "";
			$scope.Age = "";
			GetAllUsers();
		}, function errorCallback(response) {
		})

	}
	$scope.GetAllUsers = function () {
		$http({
			method: "get",
			url: "User/Get_AllUsers"
		}).then(function (response) {
			$scope.Users = response.data;
			$scope.apply();
		}, function () {
			alert("Error Occur");
		})
	};
	$scope.DeleteUser = function (User) {
		if (confirm('Do you want to delete record?')) {
			// Save it!
			$http({
				method: "post",
				url: "User/Delete_User",
				datatype: "json",
				data: JSON.stringify(User)
			}).then(function (response) {
				alert(response.data);
				//window.location.reload();
				GetAllUsers();
			})
		}
	};
	$scope.EditUser = function (User) {
		$scope.UserID = User.UserID;
		$scope.UserName = User.UserName;
		$scope.City = User.City;
		$scope.Age = User.Age;
		$scope.User = User;

	}
	function GetAllUsers() {

		$http({
			method: "get",
			url: "User/Get_AllUsers"
		}).then(function (response) {
			if (response != null) {
				$scope.Users = response.data;

			}
		}, function () {
			alert("Error Occur");
		})
	}
})  