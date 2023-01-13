import Logger from 'jet-logger';
import DemoServer from './server';

let server = new DemoServer();
server.start(3001);
