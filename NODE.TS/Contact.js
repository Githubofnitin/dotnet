var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
var ContactManager = /** @class */ (function () {
    function ContactManager() {
        this.contacts = [];
        this.currentId = 1; // To ensure unique IDs for new contacts
    }
    // Add a new contact
    ContactManager.prototype.addContact = function (contact) {
        // Assign a unique ID to the new contact
        contact.id = this.currentId++;
        this.contacts.push(contact);
        console.log("Contact added: ".concat(contact.name));
    };
    // View all contacts
    ContactManager.prototype.viewContacts = function () {
        if (this.contacts.length === 0) {
            console.log("No contacts available.");
            return [];
        }
        return this.contacts;
    };
    // Modify an existing contact
    ContactManager.prototype.modifyContact = function (id, updatedContact) {
        var contactIndex = this.contacts.findIndex(function (contact) { return contact.id === id; });
        if (contactIndex === -1) {
            console.log("Error: Contact not found.");
            return;
        }
        this.contacts[contactIndex] = __assign(__assign({}, this.contacts[contactIndex]), updatedContact);
        console.log("Contact with ID ".concat(id, " has been updated."));
    };
    // Delete a contact
    ContactManager.prototype.deleteContact = function (id) {
        var contactIndex = this.contacts.findIndex(function (contact) { return contact.id === id; });
        if (contactIndex === -1) {
            console.log("Error: Contact not found.");
            return;
        }
        this.contacts.splice(contactIndex, 1);
        console.log("Contact with ID ".concat(id, " has been deleted."));
    };
    return ContactManager;
}());
// Testing the ContactManager
var manager = new ContactManager();
// Add contacts
manager.addContact({ id: 0, name: 'John Doe', email: 'john@example.com', phone: '123-456-7890' });
manager.addContact({ id: 0, name: 'Jane Smith', email: 'jane@example.com', phone: '987-654-3210' });
// View contacts
console.log(manager.viewContacts());
// Modify a contact
manager.modifyContact(1, { phone: '111-222-3333' });
manager.modifyContact(3, { phone: '000-000-0000' }); // This should show an error
// Delete a contact
manager.deleteContact(2);
manager.deleteContact(3); // This should show an error
// View contacts after modification and deletion
console.log(manager.viewContacts());
