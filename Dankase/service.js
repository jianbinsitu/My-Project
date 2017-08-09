angular.module('mainService', [])
.factory('sendInfo', function($http, web_url){
    return{
        send: function(Info){
            return $http({
                method: 'POST',
                url: web_url.server+'saveInfo',
                data: $.param(Info),
                headers: {'content-type' : 'application/x-www-form-urlencoded'}
            }).then(function(response){
                return response;
            })
        }
    }
})

.factory('checkInfo', function($http, web_url){
    return{
        checkEmail: function(check){
            return $http({
                method: 'GET',
                url: web_url.server+'checkEmail',
                params: check,
                headers: {'Content-Type': 'application/json'}
            }).then(function(response){
                data = response.data;
                return data;
            })
        }
    }
})