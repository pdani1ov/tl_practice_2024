import { Application } from "../../types/Application";
import { Card } from "../../types/Card";
import { Deck } from "../../types/Deck";
import { addNewCard, changeCardTranslation, changeCardWord, deleteCard } from "../CardMethods"

describe("Card methods", () => {
    const card1: Card = {
        id: "1",
        word: "apple",
        translation: "яблоко"
    };
    const card2: Card = {
        id: "2",
        word: "orange",
        translation: "апельсин"
    };
    const deck: Deck = {
        id: "1",
        name: "fruits",
        cards: [card1, card2]
    };
    const app: Application = {
        decks: [deck]
    }

    describe("Add new card", () => {
        it("should add new card and return app", () => {
            const expectedResult = expect.arrayContaining([
                expect.objectContaining({
                    id: "1",
                    cards: expect.arrayContaining([
                        expect.objectContaining({
                            word: "peach",
                            translation: "персик"
                        })
                    ])
                })
            ]);
            expect(addNewCard(app, "1", "peach", "персик")).toEqual(
                expect.objectContaining({
                    decks: expectedResult
                })
            );
        });

        it("should no change if incorrect deck id", () => {
            const withoutChangesApp = {...app};
            expect(addNewCard(app, "2", "peach", "персик")).toEqual(withoutChangesApp);
        });
        
        it("should return new app", () => {
            expect(addNewCard(app, "1", "peach", "персик")).not.toBe(app);
        });
    });

    describe("Delete card", () => {
        it("should delete card and return app", () => {
            const expectedResult = expect.arrayContaining([
                expect.objectContaining({
                    id: "1",
                    cards: expect.not.arrayContaining([
                        expect.objectContaining({
                            id: "1",
                            word: "apple",
                            translation: "яблоко"
                        })
                    ])
                })
            ]);
            expect(deleteCard(app, "1", "1")).toEqual(
                expect.objectContaining({
                    decks: expectedResult
                })
            );
        });

        it("should no changes if id of deck is incorrect", () => {
            const withoutChangesApp = {...app};
            expect(deleteCard(app, "2", "1")).toEqual(withoutChangesApp);
        });

        it("should no changes if id of card is incorrect", () => {
            const withoutChangesApp = {...app};
            expect(deleteCard(app, "1", "3")).toEqual(withoutChangesApp);
        });

        it("should return new app", () => {
            expect(deleteCard(app, "1", "1")).not.toBe(app);
        });
    });

    describe("Change card word", () => {
        it("should change card word and return app", () => {
            const expectedResult = expect.arrayContaining([
                expect.objectContaining({
                    id: "1",
                    cards: expect.arrayContaining([
                        expect.objectContaining({
                            id: "1",
                            word: "newWord",
                            translation: "яблоко"
                        })
                    ])
                })
            ]);
            expect(changeCardWord(app, "1", "1", "newWord")).toEqual(
                expect.objectContaining({
                    decks: expectedResult
                })
            );
        });

        it("should no changes if id of deck is incorrect", () => {
            const withoutChangesApp = {...app};
            expect(changeCardWord(app, "2", "1", "newWord")).toEqual(withoutChangesApp);
        });

        it("should no changes if id of card is incorrect", () => {
            const withoutChangesApp = {...app};
            expect(changeCardWord(app, "1", "3", "newWord")).toEqual(withoutChangesApp);
        });

        it("should return new app", () => {
            expect(changeCardWord(app, "1", "1", "newWord")).not.toBe(app);
        });
    });

    describe("Change card translation", () => {
        it("should change card translations and return app", () => {
            const expectedResult = expect.arrayContaining([
                expect.objectContaining({
                    id: "1",
                    cards: expect.arrayContaining([
                        expect.objectContaining({
                            id: "1",
                            word: "apple",
                            translation: "newTranslation"
                        })
                    ])
                })
            ]);
            expect(changeCardTranslation(app, "1", "1", "newTranslation")).toEqual(
                expect.objectContaining({
                    decks: expectedResult
                })
            );
        });

        it("should no changes if id of deck is incorrect", () => {
            const withoutChangesApp = {...app};
            expect(changeCardTranslation(app, "2", "1", "newTranslation")).toEqual(withoutChangesApp);
        });

        it("should no changes if id of card is incorrect", () => {
            const withoutChangesApp = {...app};
            expect(changeCardTranslation(app, "1", "3", "newTranslation")).toEqual(withoutChangesApp);
        });

        it("should return new app", () => {
            expect(changeCardTranslation(app, "1", "1", "newTranslation")).not.toBe(app);
        });
    });
});