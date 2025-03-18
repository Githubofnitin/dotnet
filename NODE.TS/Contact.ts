interface Contact {
    id: number;
    name: string;
    email: string;
    phone: string;
  }

  class ContactManager {
    private contacts: Contact[] = [];
    private currentId: number = 1; // To ensure unique IDs for new contacts
  
    // Add a new contact
    addContact(contact: Contact): void {
      // Assign a unique ID to the new contact
      contact.id = this.currentId++;
      this.contacts.push(contact);
      console.log(`Contact added: ${contact.name}`);
    }
  
    // View all contacts
    viewContacts(): Contact[] {
      if (this.contacts.length === 0) {
        console.log("No contacts available.");
        return [];
      }
      return this.contacts;
    }
  
    // Modify an existing contact
    modifyContact(id: number, updatedContact: Partial<Contact>): void {
      const contactIndex = this.contacts.findIndex(contact => contact.id === id);
      if (contactIndex === -1) {
        console.log("Error: Contact not found.");
        return;
      }
      this.contacts[contactIndex] = { ...this.contacts[contactIndex], ...updatedContact };
      console.log(`Contact with ID ${id} has been updated.`);
    }
  
    // Delete a contact
    deleteContact(id: number): void {
      const contactIndex = this.contacts.findIndex(contact => contact.id === id);
      if (contactIndex === -1) {
        console.log("Error: Contact not found.");
        return;
      }
      this.contacts.splice(contactIndex, 1);
      console.log(`Contact with ID ${id} has been deleted.`);
    }
  }
  

  // Testing the ContactManager
const manager = new ContactManager();

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
