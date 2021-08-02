import mergeFiles from 'merge-files';
import path from 'path';

const __dirname = path.resolve();

const outputPath = __dirname + '/schema.graphql';

const inputPathList = [
	__dirname + '/modules/project.graphql',
	__dirname + '/modules/role.graphql',
	__dirname + '/modules/user.graphql'
];

mergeFiles(inputPathList, outputPath);
