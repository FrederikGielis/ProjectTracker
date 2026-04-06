# TODO

1. Lets first get acquainted with the project, ask copilot what the project is about (ask mode)
1. The Readme.md is little barebones right now, Let's add a section about what this project is and what it does and format it nicely so it conforms to markdown standards. You can use the output of the previous task. (agent mode)
1. Add another project in the InMemoryProjectRepository, just start typing and let copilot help you fill in the details (autocomplete)
1. Add the logo in resources/logo.svg to the header (agent mode)
1. Two birds in one stone perhaps: The GetTotalBudget method in ProjectService Seems to be calculating wrongly, it also errors if there are no projects found under a certain limit, a bugfix is needed there. (agent mode)
1. Refactor the GetByMaxBudget method in InMemoryProjectRepository to filter the projects more efficiently (agent mode / autocomplete)
1. Ask a code review about class of your choice (local / background agent mode)
1. start an agent to do a code review of the project (cloud delegation)
1. the validation in AddProject in the ProjectService is in need of unit tests. Make sure they're in the right place. Make sure the test do what they should do. Make sure to check the output. (local, background or delegation agent mode / autocomplete)
    (optional: A bunch of if-else-statements are maybe not the best way to go, a refactor might be good!)
1. Add a new feature: The projects need a start date, a good prompt and a powerful model might help.
