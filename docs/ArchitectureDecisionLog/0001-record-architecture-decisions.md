# 1.  Record architecture decisions

Date: 2024-03-01

## Problem

I need to record the architectural decisions made on this project and store it as close to code as possible.

## Decision

I will use the Architecture Decision Records concept, described by [Michael Nygard](http://thinkrelevance.com/blog/2011/11/15/documenting-architecture-decisions), to record the logs.

## Consequences

- All architectural decisions should be recorded in log
- Every time new architecture decision comes in, it is required to add new architecture decision record
- Existing architecture decision records are immutable. Whenever there is a need to update old record, a new one is created