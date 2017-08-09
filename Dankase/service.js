angular.module('mainService', [])
.factory('sendInfo', function($http, web_url){
    return{
        send: function(Info){
            console.log(Info);
            return $http({
                method: 'POST',
                url: web_url.server+'saveInfo',
                data: $.param(Info),
                headers: {'content-type' : 'application/x-www-form-urlencoded'}
            })
        }
    }
})