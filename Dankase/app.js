var mc = angular.module('mc', ['ngRoute','ui.router','mainController', 'mainService', 'ngAnimate','ngTouch', 'ngFader' ])

.constant('web_url', {
    'server': 'http://api.dankase.com/',
    'basepath': 'http://m.dankase.com/',
    'mobileserver': 'http://m.dankase.com/'
})

mc.config(function($stateProvider, $routeProvider, $urlRouterProvider,$httpProvider, web_url, $locationProvider){
    function template(templateName){
        return web_url.basepath + 'templates/' + templateName + '.html';
    }
    $locationProvider.html5Mode(true);
    $routeProvider
        .when("/", {
            templateUrl: template('landingpage')
        });
    
    $stateProvider
        .state("/", {
            url: '/',
            tempateUrl: template('landingpage')
        });
})