﻿
(function () {
    //Cria um Module
    // será usado ['ng-Route'] quando implementarmos o roteamento
    var app = angular.module('MacApp', ['ngRoute']);
    //Cria um Controller
    // aqui $scope é usado para compartilhar dados entre a view e o controller
    app.controller('HomeController', function ($scope) {
        $scope.Mensagem = "Olá.  Esse é nosso primeiro contato com o AgularJS no ASP .NEt MVC.";
    });
})();