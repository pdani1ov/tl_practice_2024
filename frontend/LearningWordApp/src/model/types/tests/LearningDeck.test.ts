import { Card } from "../Card";
import { getCurrentCard, LearningDeck, moveCurrentCardToDeckEnd, removeCurrentCard } from "../LearningDeck"

describe("Learning deck", () => {
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
    const deck: LearningDeck = {
        id: "1",
        name: "fruits",
        unlearnedCards: [card1, card2]
    };

    describe("Get current card", () => {
        it("return first card in learning deck", () => {
            expect(getCurrentCard(deck)).toEqual(card1);
        });

        it("return undefined if learning deck is empty", () => {
            const emptyDeck = { ...deck, unlearnedCards: [] };
            expect(getCurrentCard(emptyDeck)).toBeUndefined();
        });
    });

    describe("Remove current card", () => {
        it("remove current card and return deck", () => {
            const updatedDeck = { ...deck, unlearnedCards: [card2] };
            expect(removeCurrentCard(deck)).toEqual(updatedDeck);
        });

        it("no change if there are no unlearned words", () => {
            expect(removeCurrentCard({...deck, unlearnedCards: []})).toEqual({...deck, unlearnedCards: []});
        });

        it("return new deck", () => {
            expect(removeCurrentCard(deck)).not.toBe(deck);
        });
    });

    describe("Move current card to end of deck", () => {
        it("move current card to end of deck and return deck", () => {
            const updatedDeck = { ...deck, unlearnedCards: [card2, card1] };
            expect(moveCurrentCardToDeckEnd(deck)).toEqual(updatedDeck);
        });

        it("return new deck", () => {
            expect(moveCurrentCardToDeckEnd(deck)).not.toBe(deck);
        });
    });
});