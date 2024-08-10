import { Card, changeTranslationInCard, changeWordInCard } from "../Card";

describe("Card", () => {
    describe("Change word in card", () => {
        const card: Card = { id: "1", word: "lock", translation: "замок" };

        it("set new name in card and return card", () => {
            const updatedCard = { ...card, word: "castle" };
            expect(changeWordInCard(card, "castle")).toEqual(updatedCard);
        });

        it("return new card", () => {
            expect(changeWordInCard(card, "castle")).not.toBe(card);
        });
    });

    describe("Change translation in card", () => {
        const card: Card = { id: "1", word: "castle", translation: "замок" };

        it("set new translation in card and return card", () => {
            const updatedCard = { ...card, translation: "крепость" };
            expect(changeTranslationInCard(card, "крепость")).toEqual(updatedCard);
        });

        it("return new card", () => {
            expect(changeTranslationInCard(card, "крепость")).not.toBe(card);
        });
    });
});