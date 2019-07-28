"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var http_1 = require("@angular/common/http");
var PersonService = /** @class */ (function () {
    function PersonService(http) {
        this.http = http;
        this.url = "/api/person";
    }
    PersonService.prototype.getPersons = function () {
        var p = new http_1.HttpParams().append('json', JSON.stringify({ withLifeEvents: true }));
        return this.http.get(this.url, { params: p });
    };
    PersonService.prototype.getPerson = function (id) {
        return this.http.get(this.url + '/' + id);
    };
    PersonService.prototype.createPerson = function (person) {
        return this.http.post(this.url + '/' + person.id, person);
    };
    PersonService.prototype.updatePerson = function (person) {
        return this.http.put(this.url + '/' + person.id, person);
    };
    PersonService.prototype.deletePerson = function (id) {
        return this.http.delete(this.url + '/' + id);
    };
    return PersonService;
}());
exports.PersonService = PersonService;
//# sourceMappingURL=person.service.js.map