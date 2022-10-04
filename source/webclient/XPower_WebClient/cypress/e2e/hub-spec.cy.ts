
describe('hub spec', () => {
  let base_url = Cypress.env("Target_url")
  
  it('Can open site', () => {
    cy.visit(base_url)
  });

  it('Can redirect to hub with menu', () => {
    cy.visit(base_url + 'iot')

    cy.contains('menu')
      .click()

    cy.contains('Hubs').click()

    cy.get('app-hub').should(($p) => {
      expect($p.length).to.greaterThan(0);
    });
  });
})