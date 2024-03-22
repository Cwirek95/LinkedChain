# 6.  Event-driven communication between modules

Date: 2024-03-15

## Problem

Modules must communicate with each other in some way. We have to decide what will be the preferred way of communication and integration between modules.

## Decision

It was decided to use an approach such that the module sending the integration event would have its own project with integration events. It is the implementation of Publish/Subscribe pattern.

## Consequences

- We need to implement the Publish/Subscribe pattern
- The solution is going to be more complex
- The structure of events should be as stable as possible