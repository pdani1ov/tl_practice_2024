import { Card } from "../Card";
import { changeName, Deck, deleteCardFromDeck } from "./../Deck";

describe("Deck", () => {
    describe("Change name of deck", () => {
        const deck: Deck = {
            id: "1",
            name: "fruits",
            cards: []
        };

        it("Change name of deck and return deck", () => {
            const updatedDeck = {
                ...deck,
                name: "vegetables"
            }
            expect(changeName(deck, "vegetables")).toEqual(updatedDeck);
        });

        it("Return new deck", () => {
            expect(changeName(deck, "vegetables")).not.toBe(deck);
        });
    });

    describe("Delete card from deck", () => {
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

        it("removes the desired card from the deck and return the deck", () => {
            const updatedDeck = {...deck, cards: [card2]};
            expect(deleteCardFromDeck(deck, "1")).toEqual(updatedDeck);
        });

        it("entering an incorrect id does not change the deck and the deck is returned", () => {
            const updatedDeck = { ...deck };
            expect(deleteCardFromDeck(deck, "3")).toEqual(updatedDeck);
        });

        it("return new deck", () => {
            expect(deleteCardFromDeck(deck, "1")).not.toBe(deck);
        });
    });
});