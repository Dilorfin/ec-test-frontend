var grunt = require('grunt');
var glob = require('glob-all');

const distFolder = "./dist/e-commerce-test";

// workaround till (https://github.com/angular/angular-cli/issues/16997)
grunt.registerTask('move-uk', () =>
{
	glob.sync(distFolder +'/uk/*').forEach(srcPath =>
	{
		let fileName = srcPath.substring(srcPath.lastIndexOf('/') + 1);
		let destPath = distFolder + "/" + fileName;
		grunt.file.copy(srcPath, destPath);
	});
	grunt.file.delete(distFolder + '/uk/');
});

grunt.registerTask('default', ['move-uk']);
