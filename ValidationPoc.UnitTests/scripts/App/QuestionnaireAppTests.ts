/// <reference path="../../Scripts/typings/jasmine/jasmine.d.ts" />
/// <chutzpah_reference path="../../scripts/angular.js" />
/// <chutzpah_reference path="../../scripts/angular-mocks.js" />
/// <reference path="../../../ValidationPoc/scripts/App/QuestionnaireApp.ts" />
module QuestionnaireApp {
    describe("Questionnaire Controller", () => {
        var controller: QuestionnaireController;
        var modelService: any;
        var scope: IControllerScope;

        beforeEach(inject(($rootScope: ng.IRootScopeService) => {
            scope = <any>$rootScope.$new();
            modelService = jasmine.createSpyObj("modelService", ["getModel"]);
            modelService.getModel.and.returnValue(
                new QuestionnaireModel()
            );
        }));

        it("addPreviousName addes new previous name", () => {

            controller = new QuestionnaireController(scope, modelService);

            scope.addPreviousName();

            expect(scope.data.previousNames.length).toBe(1);
        });

        it("removePreviousName removed a previous name", () => {
            controller = new QuestionnaireController(scope, modelService);
            scope.data = new QuestionnaireModel();
            scope.data.previousNames.push(new PreviousName());

            scope.removePreviousName(0);
            expect(scope.data.previousNames.length).toBe(0);
        });

        it("should reset seeMoreQuestions and velocity when answerMoreQuestions is false", () => {

            var data = new QuestionnaireModel();
            data.seeMoreQuestions = true;
            data.velocity = 10;
            data.answerMoreQuestions = true;

            modelService.getModel.and.returnValue(data);

            controller = new QuestionnaireController(scope, modelService);

            scope.data.answerMoreQuestions = false;

            scope.$digest();

            expect(scope.data.seeMoreQuestions).toBe(false);
            expect(scope.data.velocity).toBe(null);

        });
    });
}