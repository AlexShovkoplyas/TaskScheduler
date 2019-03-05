import React from 'react';
import { connect } from 'react-redux';

// import CronBuilder from  'react-cron-builder'   
import 'react-cron-builder/dist/bundle.css'
import Cron from './Shared/Cron';

const Scheduler = props => (
    <div>
        <h1>Hello, world!</h1>   
    
        <Cron/>
    
    </div>  
);

export default connect()(Scheduler);