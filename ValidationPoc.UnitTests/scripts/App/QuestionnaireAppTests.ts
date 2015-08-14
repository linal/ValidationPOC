/// <reference path="../../Scripts/typings/jasmine/jasmine.d.ts"/>
/// <chutzpah_reference path="../../scripts/angular.js" />
/// <chutzpah_reference path="../../scripts/angular-mocks.js" />
/// <reference path="../../../ValidationPoc/scripts/App/QuestionnaireApp.ts"/>


describe("Questionnaire Controller", () => {
    var controller: QuestionnaireApp.QuestionnaireController;
    var scope: QuestionnaireApp.IControllerScope;

    beforeEach(inject(($rootScope: ng.IRootScopeService) => {
        scope = <any>$rootScope.$new();
    }));
   

    it("addPreviousName addes new previous name", () => {

        controller = new QuestionnaireApp.QuestionnaireController(scope);

        scope.addPreviousName();

        expect(scope.data.previousNames.length).toBe(1);
    });

    it("removePreviousName removed a previous name", () => {
        controller = new QuestionnaireApp.QuestionnaireController(scope);
        scope.data = new QuestionnaireApp.QuestionnaireModel();
        scope.data.previousNames.push(new QuestionnaireApp.PreviousName());

        scope.removePreviousName(0);
        expect(scope.data.previousNames.length).toBe(0);
    });
});