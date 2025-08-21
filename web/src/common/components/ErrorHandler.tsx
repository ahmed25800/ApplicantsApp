import { useEffect } from 'react';
import { message } from 'antd';
import  useErrorStore  from '../stores/ErrorStore';

const ErrorHandler: React.FC = () => {
  const { error, setError } = useErrorStore();

  useEffect(() => {
    debugger;
    if (error) {
        if(error.status = 400){
            if (error.errors) {
                for (const field in error.errors) {
                  error.errors[field].forEach(msg => message.error(msg));
                }
              } else {
                message.error(error.detail || error.title);
              }
        }else{
            message.error(error.detail || error.title || 'Unknown error');
        }
        setError(null);
    }
  }, [error]);

  return null;
};

export default ErrorHandler;