# TODO

1. Lets first get aqcainted with the project, ask copilot what the project is about (ask mode)
1. The Readme.md is little barebones right now, Let's add a section about what this project is and what it does and format it nicely so it conforms to markdown standards.
1. Add the logo in resources/logo.svg to the header
1. Two birds in one stone perhaps: The GetTotalBudget method in ProjectService Seems to be calculating wrongly, it also errors if there are no projects found under a certain limit, a bugfix is needed there.
1. Refactor the GetByMaxBudget method in InMemoryProjectRepository to filter the projects more efficiently
1. Ask a code review about class of your choice
1. start an agent to do task x
1. the validation in AddProject in the ProjectService is in need of unit tests. Make sure they're in the right place (optional: A bunch of if-else-statements are maybe not the best way to go, a refactor might be good!)
1. Add a new feature: The projects need a start date (prompt well and choose a powerful model!)
