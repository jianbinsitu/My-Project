angular.module('mainController', ['ngNotify'])
.controller("store", function($scope, sendInfo, $window, ngNotify){
    $scope.Infosubmit = {
        'email':'',
        'comment':'',
        'model':''
    }
    ngNotify.config({
        position: 'top',
        sticky:'true'
    })
    ngNotify.set('$10 OFF FOR THE FIRST 100 SUB');
    $scope.submit = function(){
        $scope.userInput = {
            email: $scope.Infosubmit.email,
            comment: $scope.Infosubmit.comment,
            origin: $window.location.href,
            model: $scope.Infosubmit.model
        }
        if($scope.userInput.email == ''){
            ngNotify.set('Email Field Cannot Be Empty', 'error');
        }
        else{
            sendInfo.send($scope.userInput).then(function successCallback(){
                ngNotify.set('Your Coupon Will Be Email To You Shortly', 'success');
            })
        }
    }
})