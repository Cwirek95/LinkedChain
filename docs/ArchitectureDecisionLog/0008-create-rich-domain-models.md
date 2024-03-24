# 8.  Create rich domain models

Date: 2024-03-15

## Problem

Create domain models for each module. Each domain model should represent a solution that solves a specific set of domain problems.

## Decision

Create rich domain models. Complex business logic with different rules, calculations and processing is expected, so we want to get as much as possible from object-oriented design principles such as abstraction, encapsulation, polymorphism. We want to change the state of our objects only with methods to encapsulate all the logic and hide the implementation details from the client.

## Consequences

- All objects should be encapsulated
- The implementation details of the business logic are hidden
- It is easier to protect business rules using the rich domain model
- More infrastructure work with object encapsulation