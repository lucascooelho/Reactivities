import React from "react";
import { toast } from "react-toastify";
import { Button, Header, Icon, Segment } from "semantic-ui-react";
import agent from "../../app/api/agent";
import useQuery from "../../app/common/util/hooks";

export default function RegisterSuccess() {
    const email = useQuery().get('email') as string;

    function handleConfirmationEmailResend() {
        agent.Account.resendEmailConfirm(email).then(() => {
            toast.success('Verification email resent - please check your email box');
        }).catch(error => console.log(error));
    }

    return (
        <Segment placeholder textAlign="center">
            <Header icon color="green">
                <Icon name="check" />
                Successfully registered!
            </Header>
            <p>Please check your email (including junk email) form the verification email</p>
            {email &&
                <>
                    <p>Did't receive the email? Click the below button to resend</p>
                    <Button
                        primary
                        onClick={handleConfirmationEmailResend}
                        content='Resend email'
                        size="huge"
                    />
                </>
            }
        </Segment>
    )
}