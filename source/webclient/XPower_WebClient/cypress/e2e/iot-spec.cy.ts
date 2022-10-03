
describe('Iot spec spec', () => {
  let base_url = Cypress.env("Target_url")

  it('Can redirect with menu', () => {
    cy.visit(base_url)

    cy.contains('menu')
      .click()

    cy.contains('IoT Enheder').click()

    cy.url().should('include', '/iot')
  })
})