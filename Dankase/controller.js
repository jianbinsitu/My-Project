angular.module('mainController', ['ngNotify'])
.controller("store", function($scope, sendInfo, $window, ngNotify, checkInfo){
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
        $scope.userCheck = {
            email: $scope.Infosubmit.email
        }
        if($scope.userInput.email == ''){
            ngNotify.set('E-mail Field Cannot Be Empty', 'error');
        }
        else{
            checkInfo.checkEmail($scope.userCheck).then(function successCallback(response){
                $check = response;
                if($check == ''){
                    sendInfo.send($scope.userInput).then(function successCallback(){
                        ngNotify.set('Your Coupon Will Be E-mailed To You Shortly', 'success');
                        $scope.form.$setPristine();
                        $scope.Infosubmit = {};
                    });
                }
                else{
                    ngNotify.set($check, 'error');
                }
            })
        }
    }
})