# Medieval vs Fantasy Card Combat Game

##### Workflow
First you need to clone repository. By default you are in main branch.
When you need to develop new feature you create new branch in your **local** repository.
New branch name should be like "<your_name>/<feature_name>". Shorter feature name - better.

##### Example
Check the branch you are on right now with this command
```
git branch
```
You will see branch names with * symbol at the beginning of the line. This indicates what branch you are in right now.

Create new branch with this command and switch to it
```
git branch vladimir/main_menu
git checkout vladimir/main_menu
```

Check the branch again and make sure that * is on the line with your new branch
```
git branch
```
Now you are able to open unity and work on your features

Then when you finished developing your featur you will need to create **pull request**
It's done via GitHub interface. Switch to **Pull requests** tab and press **Create pull request** button.
Specify source branch (it's your branch that you are working on) and destination branch is always **main**.

Notify dev team that you created pull request and wait for review. After getting approve merge your branch and delete it.
For each new feature/task you will create new branch and after development is finished you need to merge your changes.

##### Technical requirements
- Unity 2021.3.6f1