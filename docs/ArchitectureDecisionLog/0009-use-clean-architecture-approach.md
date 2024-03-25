# 9.  Use clean architecture approach

Date: 2024-03-15

## Problem

Modules in the application have been identified as having high technical and business complexity.  To meet these challenges, we need to implement an architectural style that can effectively handle the complexity of the modules while promoting testability.

## Decision

After careful consideration, it was decided to apply the "Clean Architecture" approach to the modules. The Clean Architecture approach emphasizes the separation of problems and the organization of code into distinct layers, promoting maintainability and testability.

## Consequences

- The complexity of the overall solution is higher - we have to add two additional layers - domain and infrastructure
- Improved overall code quality through independent testing of each layer
- In the Domain layer, we will have the same level of abstraction
- Additional effort required to create projects that will become layers