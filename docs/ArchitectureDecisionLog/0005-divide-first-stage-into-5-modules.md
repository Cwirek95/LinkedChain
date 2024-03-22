# 5.  Divide First stage of the application into 5 modules

Date: 2024-03-15

## Problem

We need to modularize our system for the first stage.

## Decision

It was decided that in the first phase of the project, we would assume that each limited context would be represented by a module with its own namespace, such as:

- Agreements
- Blockchain
- Recruitment
- Feedbacks
- UserAccess

## Consequences

- We can implement each module/Bounded Context independently
- We need to create shared libraries/classes to limit boilerplate code which will be the same in all modules
- Each module encapsulates its processes within its namespace, promoting separation of concerns
- Complexity of each module will decrease