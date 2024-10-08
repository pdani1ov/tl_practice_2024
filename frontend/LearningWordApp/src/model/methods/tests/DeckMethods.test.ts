import { Application } from "../../types/Application";
import { Deck } from "../../types/Deck";
import { addNewDeck, changeDeckName, deleteDeck } from "../DeckMethods";

describe("Deck methods", () => {
  const deck: Deck = {
    id: "1",
    name: "fruits",
    cards: [],
  };
  const app: Application = {
    decks: [deck],
  };

  describe("Add new deck", () => {
    it("should add new deck", () => {
      const newDeck = expect.objectContaining({
        name: "vegetables",
      }) as Deck;
      const expectedResult = {
        ...app,
        decks: [...app.decks, newDeck],
      };
      expect(addNewDeck(app, "vegetables")).toEqual(expectedResult);
    });

    it("should return new app", () => {
      expect(addNewDeck(app, "vegetables")).not.toBe(app);
    });
  });

  describe("Delete deck", () => {
    it("should delete deck", () => {
      const updatedApp = { ...app, decks: [] };
      expect(deleteDeck(app, "1")).toEqual(updatedApp);
    });

    it("should no changes if id of deck is incorrect", () => {
      const withoutChangesApp = { ...app };
      expect(deleteDeck(app, "2")).toEqual(withoutChangesApp);
    });

    it("should return new app", () => {
      expect(deleteDeck(app, "1")).not.toBe(app);
    });
  });

  describe("Change name of deck", () => {
    it("should change name of deck", () => {
      const updatedDeck = { ...deck, name: "newName" };
      const expectedResult = {
        ...app,
        decks: [updatedDeck],
      };
      expect(changeDeckName(app, "1", "newName")).toEqual(expectedResult);
    });

    it("should no changes if id of deck is incorrect", () => {
      const withoutChangesApp = { ...app };
      expect(changeDeckName(app, "2", "newName")).toEqual(withoutChangesApp);
    });

    it("should return new app", () => {
      expect(changeDeckName(app, "1", "newName")).not.toBe(app);
    });
  });
});
