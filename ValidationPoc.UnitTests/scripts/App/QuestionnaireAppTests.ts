/// <reference path="../tsunit/tsunit.ts" />
/// <reference path="../../../ValidationPoc/scripts/Apps/QuestionnaireApp.ts" />
module QuestionnaireAppTests {

    export class MockControllerScope implements QuestionnaireApp.IControllerScope {
        addPreviousName(): void {}

        removePreviousName(number): void {}

        data: QuestionnaireApp.QuestionnaireModel;
    }

    export class QuestionnaireControllerTests extends tsUnit.TestClass {
        addPreviousNameAddsNewPreviousName() {

            var scope = new MockControllerScope();
            var controller = new QuestionnaireApp.QuestionnaireController(scope);
            scope.addPreviousName();
            this.areIdentical(1, scope.data.previousNames.length);
        }
    }
}