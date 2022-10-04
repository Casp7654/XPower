describe('empty spec', () => {
  let base_url = Cypress.env("Target_url");

  it('can go to register', () => {
    cy.visit(base_url + 'register-user')
  });

  it('can register user', () => {
    cy.visit(base_url + 'register-user')

    let elements = cy.get('input');

    cy.get('[formcontrolname="username"]')
    .type('testuser')

    cy.get('[formcontrolname="password"]')
    .type('testpassword')

    cy.get('[formcontrolname="email"]')
    .type('te@te.dk')

    cy.get('[formcontrolname="firstname"]')
    .type('test')

    cy.get('[formcontrolname="lastname"]')
    .type('user')

    cy.contains('Opret bruger')
      .click();

    cy.url().should('not.include', '/register-user');
  })
})