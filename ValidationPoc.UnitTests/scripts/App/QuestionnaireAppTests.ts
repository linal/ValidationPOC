/// <reference path="../../Scripts/typings/jasmine/jasmine.d.ts"/>
/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular-mocks.d.ts" />
/// <reference path="../../../ValidationPoc/scripts/App/QuestionnaireApp.ts"/>

describe("calculator test", () => {
    var controller: QuestionnaireApp.QuestionnaireController;
    var scope: QuestionnaireApp.IControllerScope;

    beforeEach(inject(function($rootScope: ng.IRootScopeService) {
        scope = <any>$rootScope.$new();
    }));
   

    it("addPrviousName addes new previous name", () => {

        controller = new QuestionnaireApp.QuestionnaireController(scope);

        scope.addPreviousName();

        expect(scope.data.previousNames.length).toBe(1);
    });
});