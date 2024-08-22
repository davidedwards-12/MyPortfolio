// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function toggleProjectDetails(projectId) {
    const project = document.getElementById(projectId);
    const projectItem = project.parentElement;

    if (projectItem.classList.contains('expanded')) {
        projectItem.classList.remove('expanded');
    } else {
        document.querySelectorAll('.project-item').forEach(item => item.classList.remove('expanded'));
        projectItem.classList.add('expanded');
    }
}
