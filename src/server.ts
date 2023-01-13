import { Server } from '@overnightjs/core';
import Logger from 'jet-logger';
import * as bodyParser from 'body-parser';
import DemoController from './controller/home-controller';

class DemoServer extends Server {
    
    private readonly SERVER_START_MSG = 'Server started on port: ';

    constructor() {
        super(true);
        this.app.use(bodyParser.json());
        this.app.use(bodyParser.urlencoded({extended: true}));
        super.addControllers(new DemoController());
        
        Logger.info('Starting server in development mode');
        this.app.get('*', (req, res) => res.send('some respone'));
        
    }

    public start(port: number): void {
        this.app.listen(port, () => {
            Logger.imp(this.SERVER_START_MSG + port);
        });
    }
}

export default DemoServer;
