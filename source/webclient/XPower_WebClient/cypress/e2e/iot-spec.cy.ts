
describe('Iot spec spec', () => {
  let base_url = Cypress.env("Target_url");

  function gotoIoT() : void {
    cy.visit(base_url)

    cy.contains('menu')
      .click()

    cy.contains('IoT Enheder').click();
  };

  it('Can redirect with menu', () => {
    gotoIoT();

    cy.url().should('include', '/iot');
  });

  it('Can find 1 device', () => {
    gotoIoT();

    cy.get('app-socket').should(($p) => {
      expect($p.length).to.greaterThan(0);
    });
  });

  it('Can change status to online', () => {
    gotoIoT();

    cy.get('app-socket')
      .dblclick();

    cy.wait(500);

    cy.get('app-socket')
    .contains('electrical_services')
    .should('have.class', 'online');
  });

  it('Can change status to offline', () => {
    cy.get('app-socket')
      .dblclick();

    cy.wait(500);

    cy.contains('electrical_services')
    .should('have.class', 'offline');
  });
})