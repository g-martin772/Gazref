import { Controller, Get } from '@overnightjs/core';
import Logger from 'jet-logger';
import { Request, Response } from 'express';

@Controller('api/say-hello')
class DemoController {

    public static readonly SUCCESS_MSG = 'hello ';

    @Get(':name')
    private sayHello(req: Request, res: Response) {
        try {
            const { name } = req.params;
            if (name === 'make_it_fail') {
                throw Error('User triggered failure');
            }
            Logger.info(DemoController.SUCCESS_MSG  + name);
            return res.status(200).json({
                'message': DemoController.SUCCESS_MSG + name,
            });
        } catch (err) {
            Logger.err(err, true);
            return res.status(400).json({
                error: err,
            });
        }
    }

	@Get()
    private page(req: Request, res: Response) {
        try {
            return res.status(200).json({
                'HUI': 'Servas',
            });
        } catch (err) {
            Logger.err(err, true);
            return res.status(400).json({
                error: err,
            });
        }
    }
}

export default DemoController;
